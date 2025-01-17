﻿using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Vonage.Common.Test
{
    public class SerializationTestHelper
    {
        private const string ExcludeCommonNamespace = "Vonage.Common.Test.";
        private const string ExcludeServerNamespace = "Vonage.Server.Test.";
        private const string ExcludeVonageNamespace = "Vonage.Test.Unit.";
        private readonly string callerNamespace;

        public JsonSerializer Serializer { get; }

        public SerializationTestHelper(string callerNamespace)
        {
            this.callerNamespace = callerNamespace;
            this.Serializer = new JsonSerializer();
        }

        public SerializationTestHelper(string callerNamespace, JsonSerializer customSerializer)
            : this(callerNamespace) =>
            this.Serializer = customSerializer;

        public string GetRequestJson([CallerMemberName] string name = null) =>
            ReadFile(string.Concat(this.GetUseCaseFolder(), GetRelativeFilePath(name, FileType.Request)));

        public string GetResponseJson([CallerMemberName] string name = null) =>
            ReadFile(string.Concat(this.GetUseCaseFolder(), GetRelativeFilePath(name, FileType.Response)));

        public string GetResponseJsonForStatusCode(string statusCode, [CallerMemberName] string name = null) =>
            ReadFile(string.Concat(this.GetUseCaseFolder(), GetRelativeFilePath(name, statusCode, FileType.Response)));

        private static string CleanJsonContent(string filePath) =>
            Regex.Replace(filePath, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");

        private static string GetRelativeFilePath(string caller, FileType type) =>
            $"/Data/{caller}-{type.ToString().ToLowerInvariant()}.json";

        private static string GetRelativeFilePath(string caller, string statusCode, FileType type) =>
            $"/Data/{caller}{statusCode}-{type.ToString().ToLowerInvariant()}.json";

        private string GetUseCaseFolder() =>
            this.callerNamespace
                .Replace(ExcludeCommonNamespace, string.Empty)
                .Replace(ExcludeServerNamespace, string.Empty)
                .Replace(ExcludeVonageNamespace, string.Empty)
                .Replace('.', '/');

        private static string ReadFile(string filePath) =>
            File.Exists(filePath)
                ? CleanJsonContent(File.ReadAllText(filePath))
                : string.Empty;

        private enum FileType
        {
            Response,

            Request,
        }
    }
}