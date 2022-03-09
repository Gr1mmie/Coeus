# Coeus

Coeus is an ADSI based Situational Awareness toolkit for domain environments with modularity in mind. Allows for the enumeration of users/groups/computers as well as some common misconfigurations including roasting (AS-REP, kerber) and delegation (Constrained, Unconstrained, RCBD) attacks.

Catch my talk featuring Coeus here! (add link pls)

## To-Do
* Give option to set/change SearchScope 
* ~~Users~~
  * ~~no passwd req'd~~ 
* ~~ObjPropery~~
  * ~~parse SID/GUID~~
* LAPSSweep
* ACL Enum
  * https://www.specterops.io/assets/resources/an_ace_up_the_sleeve.pdf 
  * takes obj as param 
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
