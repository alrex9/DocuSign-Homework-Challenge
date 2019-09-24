# DocuSign-Homework-Challenge

Running this code: To run the application via command line, you will need .net sdk installed. Navigate to the folder with the files from this repo and enter 'dotnet run <params...>'

I thought of three different ways you could approach this problem.
1) Add all each server to a list the number of times the server appears. This runs into space complexity issues with larger data sets. O(n*M) space and O(n) time
2) Add each server to a frequency table, generate a random number based on how many elements were found then lookup the frequency using something resembling a bianry search. O(n) space, O(n) + O(log(n)) time
3) Get the total number of servers, pick a random number from 0 to the range, iterate over the servers again until the current index is greater than the sum of servers. O(1) space and O(2n) time which is really just O(n).
   Because option three has the lowest combination of space and time complexity I decide to go with that route. With large datasets and persistant storage, option two would probably be a better option.
