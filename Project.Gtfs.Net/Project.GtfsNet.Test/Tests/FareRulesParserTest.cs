﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project.GtfsNet.Entities;
using Project.GtfsNet.Entities.Maps;
using Project.GtfsNet.Parsers;
using Xunit;
using Xunit.Abstractions;

namespace Project.GtfsNet.Test.Tests
{
	public class FareRulesParserTest : ParserTestBase
	{
		private readonly EntityParser<FareRules, FareRulesMap> _parser = new EntityParser<FareRules, FareRulesMap>();

		public override string TestFilePath { get; } = "feeds/subway/fare_rules.txt";

		public FareRulesParserTest(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void FileIsNotEmpty()
		{
			using (TextReader textReader = GetTextReader())
			{
				IEnumerable<FareRules> parsed = _parser.Parse(textReader);
				List<FareRules> parsedList = parsed.ToList();

				Assert.NotNull(parsedList);
				Assert.True(parsedList.Any());
				Assert.Equal(18, parsedList.Count);
			}
		}

		[Fact]
		public void CheckDataIsParsedCorrectly()
		{
			using (TextReader textReader = GetTextReader())
			{
				IEnumerable<FareRules> parsed = _parser.Parse(textReader);
				List<FareRules> parsedList = parsed.ToList();

				FareRules item = parsedList[0];

				Assert.Equal("", item.ContainsId);
				Assert.Equal("", item.DestinationId);
				Assert.Equal("1", item.FareId);
				Assert.Equal("", item.OriginId);
				Assert.Equal("2315", item.RouteId);
			}
		}

	}
}