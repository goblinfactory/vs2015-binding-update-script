<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var username = "Alan";
	FixCollectionImmutableBinding( username, fromVersion:"1.1.36.0",  toVersion:"1.1.37.0");
}


public void FixCollectionImmutableBinding(string username, string fromVersion, string toVersion) {
// requiring 'from version' gives us something we can use to get a positive confirmation that have the right lines.

		Console.WriteLine("Backing up config file.");
		//===========================================
		var filepath = @"c:\Users\{user_name}\AppData\Local\Microsoft\VisualStudio\14.0\devenv.exe.config".Replace("{user_name}",username);
		var backup = filepath + ".backup." + (int)(DateTime.Now.Subtract(new DateTime(2016,1,16)).TotalSeconds);
		//File.Copy(filepath,backup);
		Console.WriteLine("Backup saved to:{0}",backup);
		
		Console.WriteLine("fixing binding for System.Collections.Immutable");
		//=================================================================
		var all = File.ReadAllLines(filepath);
		int i = 0;
		while(!all[i].Contains("name=\"System.Collections.Immutable\" publicKeyToken=\"b03f5f7f11d50a3a\"")) i++;
		var lines = new [] { all[i-1], all[i], all[i+1], all[i+2] };	
		int x = i+1;
		if(!lines[2].Contains(fromVersion)) throw new ArgumentException("Aborting script! Could not find fromVersion (" + fromVersion + ") in: " + lines[2]);
		lines.ToList().ForEach(Console.WriteLine);
		
		Console.WriteLine("Rewriting DevEnv.config");
		//==========================================
		Console.WriteLine(" ** before ** " + all[x]);
		all[x] = all[x].Replace(fromVersion, toVersion);
		Console.WriteLine(" ** after  ** " + all[x]);
		// TODO
		File.WriteAllLines(filepath,all);
		Console.WriteLine("Done.");
}



