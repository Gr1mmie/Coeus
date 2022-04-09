# Coeus

Coeus is an ADSI based Situational Awareness toolkit for domain environments with modularity in mind. Allows for the enumeration of users/groups/computers as well as some common misconfigurations including roasting (AS-REP, kerber) and delegation (Constrained, Unconstrained, RCBD) attacks.

Catch my talk featuring Coeus here! (add link pls)

[Slides!](https://github.com/Gr1mmie/Presentations/blob/main/DC615/Domain%20ADventuring%20w_%20ADSI.pdf)

## Usage
Coeus is an interactive console app, meaning executing the binary drops users into a prompt. Use `commands` to view all available commands like so: 

<img width="462" alt="image" src="https://user-images.githubusercontent.com/57014148/157974861-909690a0-f8c8-470e-929a-6d1149a1ecdf.png">

To get help for any command, use the `help` util:

<img width="477" alt="image" src="https://user-images.githubusercontent.com/57014148/157975611-fee2850d-694c-438b-af68-d7f984d61507.png">

## Features
* Enumerate users, groups (and group memberships), and computers on a domain
* Returns information on the domain and forest including domain  
* Returns information on the RootDSE 
* Searches for accounts with descriptions
* Returns "interesting accounts" (based ona string array in Models/Data.cs)
* Query object properties
* Return domain password policies 
* Returns machine accounts with SPNs assigned and their respective SPNs
* Searches for potentially AS-REP/Kerberoastable accounts
* Searcher for machines potentially vulnerable to delegation attacks (constrained, unconstrained, ~~resource based, coming soon~~)
* Query GPOs
* Query object ACL

## Compile Instructions
Open .sln in Visual Studio and build

## To-Do
* Give option to set/change SearchScope 
* ~~Users~~
  * ~~no passwd req'd~~ 
* ~~ObjPropery~~
  * ~~parse SID/GUID~~
* LAPSSweep
* RoastHunter
  * if machine w/ SPN is found, attempt to determine enc type (msDS-SupportedEncryptionTypes) and return that
  * use Coeus to locate potentially kerberoastable machines and fetch neccesary info to pass to SnipeRoast AtlasUtil 
* ACL Enum
  * https://www.specterops.io/assets/resources/an_ace_up_the_sleeve.pdf 
  * ~~takes obj as param~~
  * allow for the specifying of Identity Reference 
* ~~GPO Enum~~
  * ~~fetch all~~
  * ~~all properties~~
  * ~~specific properties~~
  * ~~return names~~
  * ~~correctly return byte[] entries (objGUID)~~
* DCSync
  * search for DS-Replication-Get-Changes, DS-Replication-Get-Changes-All, DS-Replication-Get-Changes-In-Filtered-Set  
* ~~Misc~~
  * ~~create method to convert and return SID/GIUD entries in extensions~~ 
* Authenticate
  * Allow for operator to authenticate into a domain as to not drop Coeus to disk  

## Disclaimer
I am not responsible for actions taken by users of Coeus. Coeus was released solely for educational and ethical purposes.
