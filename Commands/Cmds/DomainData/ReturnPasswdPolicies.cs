using System;
using System.Text;

using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class ReturnPasswdPolicies : Command
    {
        public override string CommandName => "PasswdPolicy";

        public override string CommandDesc => "Return domain password policy";

        public override string CommandUsage => "[*] Usage: PasswdPolicy";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Enumerating {DomainUtils.CurrentDomain(DS.searcher)} password policies\n");

            DS.entry.Path = $"LDAP://DC={DomainUtils.CurrentDomain(DS.searcher)},DC=local";

            var minPwdAge = DomainUtils.ConvertLargeIntegerToInt64(DS.entry.Properties["minPwdAge"][0]);
            var maxPwdAge = DomainUtils.ConvertLargeIntegerToInt64(DS.entry.Properties["maxPwdAge"][0]);
            var minPwdLen = DS.entry.Properties["minPwdLength"][0];
            var pwdProp = DS.entry.Properties["pwdProperties"][0];
            var pwdHistoryLen = DS.entry.Properties["pwdHistoryLength"][0];
            var lockoutDuration = DomainUtils.ConvertLargeIntegerToInt64(DS.entry.Properties["lockoutDuration"][0]);
            var lockoutObsWin = DomainUtils.ConvertLargeIntegerToInt64(DS.entry.Properties["lockoutObservationWindow"][0]);
            var lockoutThreshold = DS.entry.Properties["lockoutThreshold"][0];

            outData.AppendLine($"minPwdAge (days): {(TimeSpan.FromTicks(-minPwdAge)).ToString().Split('.')[0],-25}\n" +
                $"maxPwdAge (days): {(TimeSpan.FromTicks(-maxPwdAge)).ToString().Split('.')[0],-25}\n" +
                $"minPwdLenth: {minPwdLen,-25}\n" +
                $"pwdProperties: {pwdProp,-25}\n" +
                $"pwdHistoryLength: {pwdHistoryLen,-25}\n" +
                $"lockoutDuration (minutes): {(TimeSpan.FromTicks(-lockoutDuration)).ToString().Split(':')[1],-25}\n" +
                $"lockoutObservationWindow (minutes): {(TimeSpan.FromTicks(-lockoutObsWin)).ToString().Split(':')[1],-25}\n" +
                $"lockoutThreshold: {lockoutThreshold,-25}\n"
                );

            return outData.ToString();
        }
    }
}
