2 Constant LIST_CONS_SIZE
3 Constant LIST_METADATA_SIZE
1 Constant LIST_COUNT_OFFSET
2 Constant LIST_HEAD_OFFSET

\ list metadata:
\   remaining number of nodes
\   current number of allocated nodes
\   head of the list

: nilify-cell ( addr - )
  nil swap ! ;

: zero-cell ( addr - )
  nilify-cell ;

: list-memory-size ( n -- n )
  LIST_CONS_SIZE * LIST_METADATA_SIZE + cells ;

: list-counter ( addr -- addr1 )
  LIST_COUNT_OFFSET cells + ;

: list-get ( addr -- addr1 )
  LIST_HEAD_OFFSET cells + ;

: list-init ( addr n -- addr )
            \ input:
            \   start address
            \   number of nodes
            \ output:
            \   address of reserved address
  tuck                       \ n addr n
  list-memory-size allot     \ n addr
  tuck !                     \ addr
  dup list-counter zero-cell \ node counter
  dup list-get nilify-cell ; \ head of the list

: list-head ( addr -- addr1 )
  list-get @ ;

: list-node-count ( addr -- u )
  list-counter @ ;

: list-remaining-space ( addr -- u )
  @ ;

: list-empty? ( addr -- f )
  list-head nil = ;

: list-full? ( addr -- f )
  list-remaining-space 0 = ;

: list-dump ( addr n -- )
  list-memory-size dump cr ;

: list-first-empty ( addr -- addr1 )
  dup list-node-count LIST_CONS_SIZE *
  LIST_METADATA_SIZE + cells + ;

: list-init-cons ( n addr -- )
  tuck ! cell+ nilify-cell ;

: list-dec-remaining-space ( addr -- )
  dup @ 1- swap ! ;

: list-inc-counter ( addr -- )
  list-counter dup @ 1+ swap ! ;

: list-new ( addr n -- addr )
           \ input:
           \   address of the list
           \   payload of the new node
           \ output:
           \   address of the new allocated node
  over                         \ addr n addr
  list-first-empty             \ addr n addr1
  tuck                         \ addr addr1 n addr1
  list-init-cons               \ addr addr1
  swap                         \ addr1 addr
  dup                          \ addr1 addr addr
  list-dec-remaining-space     \ addr1 addr
  list-inc-counter ;           \ addr1
