﻿namespace mongodb.repository.Extensions;

using Contracts;

public static class MongoDbCredentialsExtensions
{
    public static string Apply(this IMongoDbCredentials credentials, string connectionString)
    {
        return connectionString
            .Replace("[username]", credentials.Username)
            .Replace("[password]", credentials.Password);
    }
}