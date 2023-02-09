using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CringeChat.DataBase
{
    public partial class ChatMishaEntities
    {
        private static ChatMishaEntities context;
        public static ChatMishaEntities GetContext()
        {
            if (context == null)
                context = new ChatMishaEntities();
            return context;
        }
    }
}
