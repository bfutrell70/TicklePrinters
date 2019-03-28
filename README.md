# TicklePrinters
Get a page from a list of IP addresses

I have Spectrum internet and am using their modem/router. Printers connect to it via Wi-Fi and are visible for a while but
if they are inactive for a while the router disconnects them. To get them working again the printer must be restarted.

I have tried the following without success:

- DHCP reservation
- static IP address

This program will connect to an list of IP addresses and attempt to read the web page associated with it. This will
(hopefully) keep the printer's connection alive. The program will need to be added as a scheduled task (Windows) or
a cron task (Linux) to be effective.  Unfortunately I don't know how long the printer has to be inactive before its
connection is severed.
