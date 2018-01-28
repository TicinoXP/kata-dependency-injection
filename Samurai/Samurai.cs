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

    public class Gun
    {
        public string UseAgainst(string target)
        {
            return $"Raise your hands, {target}, you coward!";
        }
    }

    public class Samurai
    {
        public string Attack(string target)
        {
            var attack = new Katana().UseAgainst(target);
            return $"I'm a ninja! {attack}";
        }
    }

    public class KatanaTest
    {
        [Fact]
        public void Samurai_can_use_a_katana()
        {
            var samurai = new Samurai();

            var result = samurai.Attack("Christian");

            result.Should().Be("I'm a ninja! I chop you in 2, Christian!");
        }
        
        [Fact]
        public void should_chop_people_in_two()
        {
            var sut = new Katana();

            var result = sut.UseAgainst("Christian");

            result.Should().Be("I chop you in 2, Christian!");
        }

        [Fact]
        public void should_shoot_people()
        {
            var sut = new Gun();

            var result = sut.UseAgainst("Christian");

            result.Should().Be("Raise your hands, Christian, you coward!");
        }
    }
}