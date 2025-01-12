using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CppAst;
using ReClassNET.Extensions;
using ReClassNET.Logger;
using ReClassNET.Nodes;

namespace ReClassNET.DataExchange.IDA;

public class CppClassImporter
{
	enum parseState
	{
		none,
		classDefinition,
		openingBrace,
		classBody,
	}

	/*
	public void Load(string filePath, ILogger logger)
	{
		var stream = File.ReadLines(filePath);
		const string classPattern = @"^\s*\bclass\s|\bstruct";
		var classRegex = new Regex(classPattern);
		var state = parseState.classDefinition;
		var node = new ClassNode(false);
		var classes = new List<string>();
		foreach (var line in stream)
		{
			var checkLine = line;
			if (checkLine.Contains("//"))
			{
				checkLine = checkLine.Substring(0, checkLine.IndexOf("//", StringComparison.Ordinal));
			}
			switch (state)
			{
				case parseState.classDefinition when classRegex.IsMatch(checkLine):
					{
						var name = checkLine.Split(' ')[1];
						classes.Add(name);
						state = checkLine.Contains("{") ? parseState.classBody : parseState.openingBrace;
						continue;
					}
				case parseState.openingBrace when checkLine.Contains("{"):
					state = parseState.classBody;
					continue;
				case parseState.classBody when checkLine.Contains("}"):
					state = parseState.classDefinition;
					continue;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		stream = File.ReadLines(filePath);
		foreach (var line in stream)
		{
			var checkLine = line;
			if (checkLine.Contains("//"))
			{
				checkLine = checkLine.Substring(0, checkLine.IndexOf("//", StringComparison.Ordinal));
			}
			switch (state)
			{
				case parseState.classDefinition when classRegex.IsMatch(checkLine):
					if (classRegex.IsMatch(checkLine))
					{
						node = new ClassNode(false)
						{
							Name = checkLine.Split(' ')[1]
						};
						state = checkLine.Contains("{") ? state = parseState.classBody : parseState.openingBrace;
						continue;
					}
					break;
				case parseState.openingBrace:
					if (checkLine.Contains("{"))
					{
						state = parseState.classBody;
						continue;
					}
					return;
					break;
				case parseState.classBody:
					if (checkLine.Contains("}"))
					{
						state = parseState.classDefinition;
						continue;
					}
					else
					{

					}
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
	D:\data\Projects\M2TWEOP-library\M2TWEOP Code\M2TWEOP library\realGameTypes.h
	*/
	static public void Load(string filePath, ILogger logger)
	{
		var parsed = CppParser.ParseFile(filePath);
		foreach (var cppClass in parsed.Classes)
		{
			Console.WriteLine(cppClass.ToString());
		}
	}
}