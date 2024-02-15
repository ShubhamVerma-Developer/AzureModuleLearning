A cmdlet (pronounced "command-let") is a compiled command. A cmdlet can be developed in .NET or .NET Core and invoked as a command within PowerShell. Thousands of cmdlets are available in your PowerShell installation. The challenge lies in discovering what the cmdlets are and what they can do for you.

Cmdlets are named according to a verb-noun naming standard. This pattern can help you to understand what they do and how to search for them. It also helps cmdlet developers create consistent names. You can see the list of approved verbs by using the Get-Verb cmdlet. Verbs are organized according to activity type and function.

## Locate commands by using Get-Command

```
Get-Command -Noun a-noun*
```

```
Get-Command -Verb Get -Noun a-noun*
```
