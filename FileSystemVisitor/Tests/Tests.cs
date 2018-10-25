using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        public string CurrentDirectory
        {
            get
            {
                return Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            }
        }

        public List<string> AllDirectoriesElementsList
        {
            get
            {
                return Directory.GetFileSystemEntries(CurrentDirectory, "*", SearchOption.AllDirectories).ToList();
            }
        }

        public List<string> TopDirectoryElementsList
        {
            get
            {
                return Directory.GetFileSystemEntries(CurrentDirectory, "*", SearchOption.TopDirectoryOnly).ToList();
            }
        }

        public Regex FilePattern
        {
            get
            {
                return new Regex(@"^.*\.*");
            }
        }


        [TestMethod]
        public void Unfiltered_Files()
        {
            var files = new FileSystemVisitor().GetFileList(CurrentDirectory).ToList();

            CollectionAssert.AreEquivalent(AllDirectoriesElementsList, files, "The collections are not equivalent.");
        }

        [TestMethod]
        public void Filtered_Files()
        {
            var expectedFiles = TopDirectoryElementsList.Where(x => x.EndsWith(".pdb")).ToList();
            var actualFiles = new FileSystemVisitor(x => x.Name.EndsWith(".pdb")).GetFileList(CurrentDirectory).ToList();

            CollectionAssert.AreEquivalent(expectedFiles, actualFiles, "The collections are not equivalent.");
        }

        [TestMethod]
        public void Filtered_Files_Stop_Search()
        {
            var visitor = new FileSystemVisitor(x => x.Name.Length < 40);
            visitor.FilteredFileFound += StopSearchOnceAFileFound;

            var expectedFiles = AllDirectoriesElementsList.Where(x => x.Length < 40).TakeWhile(x => !FilePattern.IsMatch(x)).ToList();
            var actualFiles = visitor.GetFileList(CurrentDirectory).ToList();

            CollectionAssert.AreEquivalent(expectedFiles, actualFiles, "The collections are not equivalent.");
        }

        [TestMethod]
        public void Filtered_Directories_Stop_Search()
        {
            var visitor = new FileSystemVisitor(x => x.Name.EndsWith(".dll"));
            visitor.FilteredFileFound += StopSearchOnceADirectoryFound;

            var expectedFiles = TopDirectoryElementsList.Where(x => x.EndsWith(".dll")).TakeWhile(x => FilePattern.IsMatch(x)).ToList();
            var actualFiles = visitor.GetFileList(CurrentDirectory).ToList();

            CollectionAssert.AreEquivalent(expectedFiles, actualFiles, "The collections are not equivalent.");

        }

        [TestMethod]
        public void Files_Exclude_From_List()
        {
            var visitor = new FileSystemVisitor();
            visitor.FilteredFileFound += ExcludeAllFiles;

            var expectedFiles = AllDirectoriesElementsList.Where(x => !FilePattern.IsMatch(x)).ToList();
            var actualFiles = visitor.GetFileList(CurrentDirectory).ToList();

            CollectionAssert.AreEquivalent(expectedFiles, actualFiles, "The collections are not equivalent.");
        }

        [TestMethod]
        public void Filtered_Directories_Exclude_From_List()
        {
            var visitor = new FileSystemVisitor(x => x.Name.EndsWith(".dll"));
            visitor.FilteredFileFound += ExcludeAllDirectories;

            var expectedFiles = TopDirectoryElementsList.Where(x => FilePattern.IsMatch(x) && x.EndsWith(".dll")).ToList();
            var actualFiles = visitor.GetFileList(CurrentDirectory).ToList();

            CollectionAssert.AreEquivalent(expectedFiles, actualFiles, "The collections are not equivalent.");
        }

        public void StopSearchOnceAFileFound(object sender, FileFoundEventArgs args)
        {

            if (FilePattern.IsMatch(args.FileName))
            {
                (sender as FileSystemVisitor).CompleteSearch(); 
            }
        }

        public void StopSearchOnceADirectoryFound(object sender, FileFoundEventArgs args)
        {

            if (!FilePattern.IsMatch(args.FileName))
            {
                (sender as FileSystemVisitor).CompleteSearch();
            }
        }

        public void ExcludeAllFiles(object sender, FileFoundEventArgs args)
        {
            if (FilePattern.IsMatch(args.FileName))
            {
                (sender as FileSystemVisitor).SkipFile(args.FileName);
            }
        }

        public void ExcludeAllDirectories(object sender, FileFoundEventArgs args)
        {

            if (!FilePattern.IsMatch(args.FileName))
            {
                (sender as FileSystemVisitor).SkipFile(args.FileName);
            }
        }
    }
}
