using Newtonsoft.Json.Linq;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace KingRaamVoiceBot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var Token = "6087364990:AAGcP7U8yShaBfxIWon2HIjolXzaAYZqoRQ";
            var bot = new TelegramBotClient(Token);
            //533671108 Raam
            try
            {
                int offset = 0;
                Update[] update = bot.GetUpdatesAsync(offset).Result;

                while (true)
                {
                    update = bot.GetUpdatesAsync(offset).Result;
                    foreach (var up in update)
                    {
                        offset = up.Id + 1;

                        var text = up.Message.Text;
                        var from = up.Message.From;
                        var chatId = up.Message.Chat.Id;

                        if (!string.IsNullOrEmpty(text) && (text.Contains("/start") || text.Contains("/Start")))
                        {
                            StringBuilder sb = new();
                            sb.Append("سلام من King Raam هستم. لطفا پیام خودتون رو به صورت Voice کوتاه یا متن ارسال کنید.");
                            bot.SendTextMessageAsync(chatId, sb.ToString(), ParseMode.Markdown, null, false, false);
                        }
                        else
                        {
                            StringBuilder sb = new();
                            sb.Append("پیام شما به دست من رسید ممنون از پیام شما.");
                            bot.ForwardMessageAsync("195359531", chatId, up.Message.MessageId);
                            bot.SendTextMessageAsync(chatId, sb.ToString(), ParseMode.Markdown, null, false, false);
                        }

                        Console.WriteLine(chatId + " - " + from.Username + " - " + text + " - " + up.Message.MessageId + " - " + DateTime.Now.Time() + " - " + DateTime.Today.ToShamsi());
                    }
                }
            }
            catch (Exception e)
            {
                bot.SendTextMessageAsync("195359531", e.StackTrace.ToString() + "\n" + e.ToString());
            }
        }

    }
}