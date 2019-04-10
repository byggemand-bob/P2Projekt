﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Poker_Game {
    class StatisticWriter {
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;
        private readonly string _folderPath;
        private readonly string _fileName;

        //File info

        public StatisticWriter(string playerName) {
            _folderPath = System.Windows.Forms.Application.StartupPath + "\\Statistics\\";
            _fileName = playerName + ".stats";

            EnsureDirectoryExists(_folderPath);
            EnsureFileExists(_folderPath + _fileName);
            
        }

        private void EnsureDirectoryExists(string folderPath) {
            FileInfo fileInfo = new FileInfo(folderPath);
            if(!fileInfo.Directory.Exists) {
                System.IO.Directory.CreateDirectory(fileInfo.DirectoryName);
            }
        }

        private void EnsureFileExists(string filePath) {
            if(!File.Exists(filePath)) {
                StreamWriter sw = new StreamWriter(filePath);
                
            }
        }

        public void SaveHand(Hand hand) {
           
        }


        private void GetInfoFromFile() {
            string buffer;
            _streamReader = new StreamReader(_folderPath + _fileName);
            buffer = _streamReader.ReadLine();
            buffer.Split(',');

        }

        // _streamWriter = new StreamWriter(_folderPath + _fileName);




    }
}