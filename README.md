# About
These are simple projects with the minimal configuration needed to run "Quartz", "Background Service", and "Hosted Service". <br />
These examples demonstrate how to use each approach to solve different types of background processing tasks in .NET applications.

# When should you use each one?
__Quatz:__ when you have to process some data in a specific day/date time. <br />
_Ex.: Imagine you need to send a daily report at 8 AM_
<br /><br />


__Background Service:__ when you have a interrupting processes to verify something. <br />
_Ex.: Imagine a service that checks every 5 seconds if there are new messages to process_
<br /><br />


__Hosted Service:__ when you have a process with start and finish once
_Ex.: Imagine a service that performs initialization tasks at the start of the application_
<br /><br />
