﻿namespace Bitspace.Tests.Factories;

public static class CloudsResponseModelFactory
{
    public static CloudsResponseModel GetModel()
    {
        return GetModels(1).First();
    }

    public static CloudsResponseModel[] GetModels(int count = 5)
    {
        return new Faker<CloudsResponseModel>()
            .RuleFor(x => x.All, f => f.Random.Int())
            .Generate(count).ToArray();
    }
}