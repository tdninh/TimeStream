using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace TimeStream
{
    public partial class FriendList : PhoneApplicationPage
    {
        ObservableCollection<ConversationViewMessage> messageOnChatView = new ObservableCollection<ConversationViewMessage>();
        public FriendList()
        {
            InitializeComponent();

            ConversationViewMessage msg = new ConversationViewMessage("Hello! Than Thanh An", DateTime.Now, ConversationViewMessageType.Outgoing);
            messageOnChatView.Add(msg);
            Cons_ChatView.DataContext = messageOnChatView;
            
        }

        private void Cons_ChatView_Tap(object sender, ConversationViewMessageEventArgs e)
        {
            messageOnChatView.Add(new ConversationViewMessage(Cons_ChatView.Text.ToString(), DateTime.Now, ConversationViewMessageType.Incoming));
            Cons_ChatView.Text = new string(' ', 1); 
        }
    }
}