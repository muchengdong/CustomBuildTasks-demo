using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CustomBuildTasks
{
    public class MyBuildTask : Task
    {

        private static readonly byte[] AesKey = Encoding.UTF8.GetBytes("123456CheckKey00");
        private static readonly byte[] AesIV = Encoding.UTF8.GetBytes("Vector4123451234");

        [Required]
        public string TargetDirectory { get; set; }

        public override bool Execute()
        {
            try
            {
                string runtimeDir = Path.Combine(TargetDirectory, "Runtime");
                if (!Directory.Exists(runtimeDir))
                {
                    Directory.CreateDirectory(runtimeDir);
                }

                string anchorFilePath = Path.Combine(runtimeDir, "xx.xx.xx.dll");
                if (File.Exists(anchorFilePath))
                {
                    File.SetAttributes(anchorFilePath, FileAttributes.Normal);
                }

                string plainText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

                byte[] cipherBytes;
                using (Aes aes = Aes.Create())
                {
                    aes.Key = AesKey;
                    aes.IV = AesIV;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(plainBytes, 0, plainBytes.Length);
                            cs.FlushFinalBlock();
                        }
                        cipherBytes = ms.ToArray();
                    }
                }

                File.WriteAllBytes(anchorFilePath, cipherBytes);
                File.SetAttributes(anchorFilePath, FileAttributes.Hidden | FileAttributes.System);
                Log.LogMessage(MessageImportance.High, "====== [MSBuild 插件] 成功生产安全时间锚点！ ======");
                Log.LogMessage(MessageImportance.High, $"====== [MSBuild 插件] 出厂时间锁定为: {plainText} ======");

                return true;
            }
            catch (Exception ex)
            {
                Log.LogError($"====== [MSBuild 插件] 发生致命错误: {ex.Message}");
                return false;
            }
        }
    }
}
