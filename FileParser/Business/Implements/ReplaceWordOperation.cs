﻿using System;
using FileParser.Business.Interfaces;
using FileParser.FilesManagers.Interfaces;
using FileParser.Model;

namespace FileParser.Business
{
    public class ReplaceWordOperation : IOperation
    {
        #region Private Members

        private readonly IFileManager fileManager;

        #endregion

        public ReplaceWordOperation(IFileManager fileManager)
        {
            this.fileManager = fileManager ??
                throw new ArgumentNullException(nameof(fileManager));
        }

        public bool CanProcess(Operation operation)
        {
            return operation == Operation.Replace;
        }

        public void Process(InputData inputData)
        {
            var text = fileManager.ReadText();

            text = text.Replace(inputData.SearchWord, inputData.ReplaceableWord);

            fileManager.WriteText(text);
        }
    }
}