S" linked list file" type cr

2 Constant LIST_CONS_SIZE
2 Constant LIST_METADATA_SIZE

: nilify-cell ( addr - )
              \ input:
              \   address of the memory cell to be set to nil
  nil swap ! ;

: list-memory-size ( n -- n )
  LIST_CONS_SIZE * LIST_METADATA_SIZE + cells ;

: list-reserve-memory ( addr n -- addr )
                      \ input:
                      \   start address
                      \   number of nodes
                      \ output:
                      \   address of reserved address
  tuck                    \ n addr n
  list-memory-size allot  \ n addr
  swap over !             \ addr
  dup cell+ nilify-cell ; \ second cell points to the first cell of the list

: list-head ( addr -- u )
  cell+ @ ;

: list-remaining-space ( addr -- u )
  @ ;

: list-empty? ( addr -- f )
  list-head nil = ;

: list-dump ( addr n -- )
  list-memory-size dump ;
