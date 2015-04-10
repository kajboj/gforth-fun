require assert.fs
require linked_list.fs

1 Constant DATA_SIZE
4 Constant LIST_SIZE

here DATA_SIZE LIST_SIZE list-reserve-memory
dup DATA_SIZE LIST_SIZE * 2 + cells dump

S" list should be initially empty"
list-empty? true <> assert

.s cr
