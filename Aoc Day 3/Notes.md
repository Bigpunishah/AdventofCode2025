
# **Notes**

## Regex:
```c#
string regexpattern = @"mul+\(\d+,\d+\)"; 
Meaning //mul + ( integer , integer ) 
```

- \\( and \\) — Match literal parentheses.

- ==Not used== \s* — Optional whitespace (before/after numbers or comma).

- ==Not used== -? — Optional negative sign. 

- \d+ — One or more digits.

- , — The comma separating the integers.