using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private readonly static String securityKey = "!@#$%^&*";
        private readonly static String securityIv = "J~i!a@n#g$.%1^1&0*6";
        private readonly static String securityHolder = Guid.NewGuid().ToString();
        private readonly static String dbFilePath = @".\data.csv";
        private readonly static List<String> Characters = new List<String>() { "~", "!", "#", "$", "%", "^", "&", "*", ".", "(", ")", "-", "_", "=", "+", "/", @"\", "*", "`" };

        private String applicationName;
        public String SecurityKey { get { return this.applicationName; } set { this.applicationName = value; RaisePropertyChanged("SecurityKey"); } }

        private String generatorPassword;
        public String SecurityValue { get { return this.generatorPassword; } set { this.generatorPassword = value; RaisePropertyChanged("SecurityValue"); } }

        private Int32 passwordLength;
        public MainWindow()
        {
            InitializeComponent();
            var length = ConfigurationManager.AppSettings["passwordLength"];
            if (Int32.TryParse(length, out this.passwordLength) == false)
            {
                this.passwordLength = 20;
            }
            this.DataContext = this;
        }

        private static String Encrypt(String password)
        {
            String result = String.Empty;
            byte[] rgbKkey = Encoding.UTF8.GetBytes(securityKey);
            byte[] rgbIV = Encoding.UTF8.GetBytes(securityIv);
            byte[] data = Encoding.UTF8.GetBytes(password);

            using (var descsp = new DESCryptoServiceProvider())
            {
                using (var stream = new MemoryStream())
                {
                    using (var crypto = new CryptoStream(stream, descsp.CreateEncryptor(rgbKkey, rgbIV), CryptoStreamMode.Write))
                    {
                        crypto.Write(data, 0, data.Length);
                    }
                    result = Convert.ToBase64String(stream.ToArray());
                }
            }
            return result;
        }

        private static String Decrypt(String securityString)
        {
            String result = String.Empty;
            byte[] rgbKey = Encoding.UTF8.GetBytes(securityKey);
            byte[] rgbIV = Encoding.UTF8.GetBytes(securityIv);
            byte[] data = Encoding.UTF8.GetBytes(securityString);
            byte[] buffer = Convert.FromBase64String(securityString);
            using (var descsp = new DESCryptoServiceProvider())
            {
                using (var stream = new MemoryStream(buffer))
                {
                    using (var crypto = new CryptoStream(stream, descsp.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(crypto))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            return result;
        }

        private void Generator(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.GetSecurity() == false)
                {
                    if (String.IsNullOrEmpty(this.SecurityKey))
                    {
                        MessageBox.Show("请填写ApplicationName!");
                    }
                    else
                    {
                        var appender = new StringBuilder();
                        appender.Append(DateTime.Now.ToString("MMddyyyyHHmmss"));
                        appender.Append(securityHolder);
                        appender.Append(SecurityKey);
                        var random = new Random((Int32)DateTime.Now.Ticks);
                        var temp = Encrypt(appender.ToString());
                        temp = temp.Substring(random.Next(temp.Length - this.passwordLength / 2), this.passwordLength / 2);
                        appender.Clear();
                        for (Int32 flag = 0; flag < temp.Length; flag++)
                        {
                            appender.Append(temp[flag]);
                            appender.Append(Characters[random.Next(Characters.Count - 1)]);
                        }
                        this.SecurityValue = appender.ToString();
                        this.SecurityValue = this.SecurityValue.PadRight(this.passwordLength, ':');
                        this.SaveSecurity();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveSecurity()
        {
            try
            {
                using (var writer = new StreamWriter(dbFilePath, true, Encoding.Default))
                {
                    StringBuilder appender = new StringBuilder();
                    appender.Append(this.SecurityKey).Append(",");
                    appender.Append(this.SecurityValue).Append(",");
                    appender.Append(Environment.NewLine);
                    writer.Write(appender.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Boolean GetSecurity()
        {
            var result = false;
            this.SecurityValue = String.Empty;
            try
            {
                if (File.Exists(dbFilePath) == true)
                {
                    using (var reader = new StreamReader(dbFilePath, Encoding.Default))
                    {
                        var temp = reader.ReadLine();
                        while (temp != null)
                        {
                            if (temp.StartsWith(this.SecurityKey))
                            {
                                var array = temp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                if (array.Length == 2)
                                {
                                    this.SecurityValue = array[1];
                                    result = true;
                                    break;
                                }
                            }
                            temp = reader.ReadLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Acquire(object sender, RoutedEventArgs e)
        {
            this.GetSecurity();
        }

        private void Paste(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.SecurityValue) == false)
            {
                Clipboard.SetText(this.SecurityValue);
            }
        }
    }
}
