require assert.fs
require linked_list.fs

1 Constant DATA_SIZE
4 Constant LIST_SIZE

here DATA_SIZE LIST_SIZE list-reserve-memory
dup DATA_SIZE LIST_SIZE * 2 + cells dump

dup list-remaining-space LIST_SIZE =
S" list should have initially all node space available" assert

dup list-empty? true =
S" list should be initially empty" assert

.s cr
