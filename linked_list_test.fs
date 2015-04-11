require assert.fs
require linked_list.fs

4 Constant LIST_SIZE

here LIST_SIZE list-init

dup list-display

dup list-remaining-space LIST_SIZE =
S" list has initially all node space available" assert

dup list-empty? true =
S" list is initially empty" assert

dup list-full? false =
S" list is not full" assert

\ after allocating new node

dup 13 list-new over

dup list-empty? true =
S" list is empty" assert

dup list-full? false =
S" list is not full" assert

dup list-remaining-space 3 =
S" available space dropped by 1" assert

\ after inserting one node

list-get      \ l a h
swap          \ l h a
tuck          \ l a h a
list-ins      \ l a

over list-head =
S" added node is at the head" assert

dup list-display
                     \ l
dup                  \ l l
7 list-new           \ l a
over list-get swap   \ l h a
list-ins             \ l

dup LIST_SIZE list-dump
dup list-display
.s cr
