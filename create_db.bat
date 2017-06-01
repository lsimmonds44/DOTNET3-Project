echo off

rem batch file to run a script to create a db rem 11/29/2016

sqlcmd -S localhost -E -i gardenDatabase.sql

ECHO if no error message appears DB was created
PAUSE