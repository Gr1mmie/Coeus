rule CoeusCommands_Yara {
    meta:
        last_updated = "2021-3-3"
        author = "Grimmie"
        description = "Searches for strings present in an unmodified version of Coeus (i.e command names, namespaces, etc.)"

    strings:
        // internal namespaces  
        $CoeusNamespace1 = "Coeus.Utils" nocase ascii
        $CoeusNamespace2 = "Coeus.Models" nocase ascii

        // system namespaces
        $SystemNamespace1 = "System.Runtime.InteropServices" nocase ascii
        $SystemNamespace2 = "System.Runtime.CompilerServices" nocase ascii
        $SystemNamespace3 = "System.DirectoryServices" nocase ascii
        $SystemNamespace4 = "System.Diagnostics" nocase ascii
        $SystemNamespace5 = "System.Collections.Generic" nocase ascii
        $SystemNamespace6 = "System.Core" nocase ascii
        $SystemNamespace7 = "System.Linq" nocase ascii

        // extension methods
        $Extension1 = "ConvertLargeIntegerToInt64" nocase ascii

        // commands
        $Command1 = "SearchDCSync" nocase ascii
        $Command2 = "LocateExchange" nocase ascii
        $Command3 = "SPNSnipe" nocase ascii
        $Command4 = "ACLEnum" nocase ascii
        $Command5 = "ReturnDomain" nocase ascii
        $Command6 = "SearchDelegation" nocase ascii
        $Command7 = "GPOHunter" nocase ascii
        $Command8 = "DescriptionHunter" nocase ascii
        $Command9 = "InterestingAccounts" nocase ascii
        $Command10 = "SearchRoast" nocase ascii
        $Return1 = "ReturnGroupMembers" nocase ascii
        $Return2 = "ReturnDomainControllers" nocase ascii
        $Return3 = "ReturnPrinters" nocase ascii
        $Return4 = "ReturnAllGroupObjects" nocase ascii
        $Return5 = "ReturnAllUserObjects" nocase ascii
        $Return6 = "ReturnAllComputerObjects" nocase ascii
        $Return7 = "ReturnObjProperty" nocase ascii

        // misc. varables and whatnot
        $Auxiliary1 = "RootDSE" nocase ascii
        $Auxiliary2 = "CommandExec" nocase ascii
        $Auxiliary3 = "UtilDesc" nocase ascii
        $Auxiliary4 = "FindOne" nocase ascii
        $Auxiliary5 = "ReadLine" nocase ascii
        $Auxiliary6 = "TimeSpan" nocase ascii
        $Auxiliary7 = "Action" nocase ascii
        $Auxiliary8 = "DirectorySearcher" nocase ascii



    condition:
        all of ($Coeus* and $System*) and 
        all of ($Command* and $Return* and $Extension1) and
        all of $Auxiliary*
}