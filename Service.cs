using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESInfoCenter
{
    
    internal class Service
    {

        public string appName { get; set; }
        public string appPath { get; set; }
        public string appRepoPath { get; set; }
        public string appIMGPath { get; set; }
        public string appGuidePath { get; set; }
        public string appDes { get; set; }

        public void addApp(List<string> data)
        {
            this.appName = data[0];
            this.appPath = data[1];
            this.appRepoPath = data[2];
            this.appIMGPath = data[3];
            this.appGuidePath = data[4];
            this.appDes = data[5];
        }

        public void updateApp(int ID)
        {

        }

        public void deleteApp(int ID) 
        {

        }

        public void getAppList()
        {

        }

        public void getAppByID(int ID)
        {

        }
        public void addTroubleShooting()
        {

        }

        public void getTroubleShootingList()
        {

        }

        public void getTroubleShootingByID(int ID)
        {

        }
        //public List<string> getAppData()
        //{

        //}



    }


}
