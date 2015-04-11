require assert.fs
require linked_list.fs

4 Constant LIST_SIZE

here LIST_SIZE list-reserve-memory
dup LIST_SIZE list-dump

dup list-remaining-space LIST_SIZE =
S" list should have initially all node space available" assert

dup list-empty? true =
S" list should be initially empty" assert

.s cr
