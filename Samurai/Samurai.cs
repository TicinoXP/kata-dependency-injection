﻿using FluentAssertions;
using Xunit;

namespace Samurai
{
    public interface IWeapon
    {
        string UseAgainst(string target);
    }

    public class Katana : IWeapon
    {
        public string UseAgainst(string target)
        {
            return $"I chop you in 2, {target}!";
        }
    }

    public class Gun : IWeapon
    {
        public string UseAgainst(string target)
        {
            return $"Raise your hands, {target}, you coward!";
        }
    }

    public class Samurai
    {
        private readonly IWeapon _weapon;

        public Samurai(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public string Attack(string target)
        {
            var attack = _weapon.UseAgainst(target);
            return $"I'm a ninja! {attack}";
        }
    }

    public class KatanaTest
    {
        [Fact]
        public void Samurai_can_use_a_gun()
        {
            var samurai = new Samurai(new Gun());

            var result = samurai.Attack("Christian");

            result.Should().Be("I'm a ninja! Raise your hands, Christian, you coward!");
        }

        [Fact]
        public void Samurai_can_use_a_katana()
        {
            var samurai = new Samurai(new Katana());

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