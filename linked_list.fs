2 Constant LIST_CONS_SIZE
3 Constant LIST_METADATA_SIZE
1 Constant LIST_COUNT_OFFSET
2 Constant LIST_HEAD_OFFSET

\ list metadata:
\   remaining number of nodes
\   current number of allocated nodes
\   head of the list

: nilify-cell ( a - )
  nil swap ! ;

: zero-cell ( a - )
  nilify-cell ;

: nil? ( a - f )
  nil = ;

: list-memory-size ( n -- n )
  LIST_CONS_SIZE * LIST_METADATA_SIZE + cells ;

: list-counter ( a -- a1 )
  LIST_COUNT_OFFSET cells + ;

: list-get ( a -- a1 )
  LIST_HEAD_OFFSET cells + ;

: list-init ( a n -- a )
            \ input:
            \   start address
            \   number of nodes
            \ output:
            \   address of reserved address
  tuck                       \ n a n
  list-memory-size allot     \ n a
  tuck !                     \ a
  dup list-counter zero-cell \ node counter
  dup list-get nilify-cell ; \ head of the list

: list-head ( a -- a1 )
  list-get @ ;

: list-node-count ( a -- u )
  list-counter @ ;

: list-remaining-space ( a -- u )
  @ ;

: list-empty? ( a -- f )
  list-head nil = ;

: list-full? ( a -- f )
  list-remaining-space 0 = ;

: list-dump ( a n -- )
  list-memory-size dump cr ;

: list-first-empty ( a -- a1 )
  dup list-node-count LIST_CONS_SIZE *
  LIST_METADATA_SIZE + cells + ;

: list-init-cons ( n a -- )
  tuck ! cell+ nilify-cell ;

: list-dec-remaining-space ( a -- )
  dup @ 1- swap ! ;

: list-inc-counter ( a -- )
  list-counter dup @ 1+ swap ! ;

: list-new ( a n -- a )
           \ input:
           \   address of the list
           \   payload of the new node
           \ output:
           \   address of the new allocated node
  over                         \ a n a
  list-first-empty             \ a n a1
  tuck                         \ a a1 n a1
  list-init-cons               \ a a1
  swap                         \ a1 a
  dup                          \ a1 a a
  list-dec-remaining-space     \ a1 a
  list-inc-counter ;           \ a1

: list-ins ( a1 a2 -- )
           \ head new-node
  over @        \ h n t
  over cell+ !  \ h n
  swap ! ;

: list-display-rec ( a -- )
  dup nil? if
    drop S" nil" type
  else
    dup
    @ .
    cell+ @ recurse
  endif ;

: list-display-sep ( -- )
  S" | " type ;

: list-display ( a -- )
  dup list-remaining-space . list-display-sep
  dup list-node-count . list-display-sep
  list-head
  list-display-rec
  cr ;

: list-tail ( a1 -- a2 )
  cell+ ;

