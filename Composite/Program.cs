Console.Title = "Composite";

var root = new Composite.Directory("root", 0);
var topLevelFile = new Composite.File("toplevel.txt", 100);
var topLevelDirectory1 = new Composite.Directory("topLevelDirectory1", 4);
var topLevelDirectory2 = new Composite.Directory("topLevelDirectory2", 4);

root.AddFileSystemItem(topLevelFile);
root.AddFileSystemItem(topLevelDirectory1);
root.AddFileSystemItem(topLevelDirectory2);

var subLevelFile1 = new Composite.File("sublevel1.txt", 200);
var subLevelFile2 = new Composite.File("sublevel2.txt", 150);

topLevelDirectory2.AddFileSystemItem(subLevelFile1);
topLevelDirectory2.AddFileSystemItem(subLevelFile2);

Console.WriteLine($"Size of topLevelDirectory1: {topLevelDirectory1.GetSize()}");
Console.WriteLine($"Size of topLevelDirectory2: {topLevelDirectory2.GetSize()}");
Console.WriteLine($"Size of root: {root.GetSize()}");

Console.ReadKey();