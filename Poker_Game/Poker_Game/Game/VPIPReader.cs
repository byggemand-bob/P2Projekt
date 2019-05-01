using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.Game {
    class VPIPReader {
        private readonly string _filePath;

        public VPIPReader(string playerName) {
            _filePath = CreateFilePath(playerName);
        }

        private string CreateFilePath(string playerName) {
            return System.Windows.Forms.Application.StartupPath + "\\VPIPData\\" + playerName + ".vpip";
        }

        public VPIPData ReaData() {
            StreamReader sr = new StreamReader(_filePath);
            return new VPIPData(sr.ReadLine(),
                Int32.Parse(sr.ReadLine()), 
                Int32.Parse(sr.ReadLine()), 
                Int32.Parse(sr.ReadLine()));
            sr.Close();
        }
    }
}
