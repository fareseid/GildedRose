# GildedRose Refactoring

 This is my implementation of the refactoring of [GildedRose](https://github.com/emilybache/GildedRose-Refactoring-Kata).

## Requirements
    
- Once the sell by date has passed, Quality degrades twice as fast
- The Quality of an item is never negative
- "Aged Brie" actually increases in Quality the older it gets
- The Quality of an item is never more than 50
- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
Quality drops to 0 after the concert
- "Conjured" items degrade in Quality twice as fast as normal items

## Commit Flow

1. **Add Unit Tests**\
    *I Started with covering the code in unit tests before doing any refactoring.*

2. **Add New Models And Tests**\
    *In parallel with the existing code, I started implementing the Models that will be used in the new implementation along with their tests.*

3. **Add Item Type And Factory**\
    *In parallel with the existing code, I created the item type enum with its factory to map it to an UpdatableItem along with their tests.*

4. **Branch The New Code**\
    *I refactored GildedRose to use the new implementation without modifying any tests.*

5. **Add Conjured**\
    *Given the new implementation, I can now extend the updatable item and implement a new type, a Conjured Item.*

6. **Restructuring**\
    *I followed the best practices to seperate the [unit tests](Test) from the [main](main).*

    
## How to

### Build Main
 
```bash
nuget install main/packages.config -OutputDirectory packages
cd main
dotnet build
```

### Build Test
 
```bash
nuget install test/packages.config -OutputDirectory packages
cd test
dotnet build
```

### Run 

```bash
cd main
start bin/Debug/csharp.exe
``` 

### Test
 
```bash
cd test
dotnet test
``` 

## Ownership Issue
I assumed that program.cs cannot be modified but in order to fix the ownership issue i mentioned in the comment, I created the branch  [FixOwnership Branch](https://github.com/fareseid/GildedRose/tree/FixOwnership)