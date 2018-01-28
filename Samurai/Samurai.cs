using System;
using FluentAssertions;
using Xunit;

namespace Samurai
{
    public class Katana
    {
        public string UseAgainst(string target)
        {
            return $"I chop you in 2, {target}!";
        }
    }

    public class KatanaTest
    {
        [Fact]
        public void should_chop_people_in_two()
        {
            var sut = new Katana();

            var result = sut.UseAgainst("Christian");


            result.Should().Be("I chop you in 2, Christian!");
        }
    }
}