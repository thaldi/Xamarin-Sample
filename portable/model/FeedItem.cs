using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace natGeo_rss.model
{
    public class FeedItem : INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value != title)
                {
                    title = value;
                    OnPropertyChanged(title);
                }
            }
        }

        private string desc;
        public string Description
        {
            get
            {
                return desc;
            }
            set
            {
                if (value != desc)
                {
                    desc = value;
                    OnPropertyChanged(desc);
                }
            }
        }

        private string link;
        public string Link
        {
            get
            {
                return link;
            }
            set
            {
                if (value != link)
                {
                    link = value;
                    OnPropertyChanged(link);
                }
            }
        }


        private string publishdate;
        public string PublishTime
        {
            get
            {
                return publishdate;
            }
            set
            {
                if (value != publishdate)
                {
                    publishdate = value;
                    OnPropertyChanged(publishdate);
                }
            }
        }

        private string cate;
        public string Category
        {
            get
            {
                return cate;
            }
            set
            {
                if (value != cate)
                {
                    cate = value;
                    OnPropertyChanged(cate);
                }
            }

        }

        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged(id.ToString());
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
