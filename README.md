# Coeus

Coeus is an ADSI based Situational Awareness toolkit for domain environments with modularity in mind. Allows for the enumeration of users/groups/computers as well as some common misconfigurations including roasting (AS-REP, kerber) and delegation (Constrained, Unconstrained, RCBD) attacks.

Catch my talk featuring Coeus here! (add link pls)

## To-Do
* Give option to set/change SearchScope 
* Users
  * no passwd req'd 
  * add opt to return group membership
* ObjPropery
  * parse SID/GUID
* LAPSSweep
* ACL Enum
  * takes obj as param 
* GPO Enum
  * fetch all
  * all properties
  * specific properties
  * return names     
* DCCync
  * search for DS-Replication-Get-Changes, DS-Replication-Get-Changes-All, DS-Replication-Get-Changes-In-Filtered-Set  
