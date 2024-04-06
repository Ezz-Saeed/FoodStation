namespace FoodCorner.Settings
{
    public class ConfirmEmail
    {
        private string filePath = $"{Directory.GetCurrentDirectory()}\\Views\\Account\\ConfirmEmail.cshtml";
        public string GetEmailBody()
        {
            var str = new StreamReader(filePath);
            var mailText = str.ReadToEnd();
            str.Close();
            return mailText;
        }
    }
}
