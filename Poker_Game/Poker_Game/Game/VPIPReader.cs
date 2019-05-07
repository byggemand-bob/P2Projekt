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


        // checks if the StreamWriter has the correct filePath to write to, and writes info to the file
        public bool HasExistingData() {
            return File.Exists(_filePath);
        }


        public VPIPData ReadData() {
            StreamReader sr = new StreamReader(_filePath);
            VPIPData result = new VPIPData(sr.ReadLine(),
                Int32.Parse(sr.ReadLine()), 
                Int32.Parse(sr.ReadLine()), 
                Int32.Parse(sr.ReadLine()));
            sr.Close();
            return result;
        }
    }
}
