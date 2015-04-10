S" linked list file" type cr

: list-reserve-memory ( addr n n -- addr )
                      \ input:
                      \   start address
                      \   size of node data
                      \   number of nodes
                      \ output:
                      \   address of reserved address
  dup >r
  * cells
  cell+               \ one cell for remaining space as number of nodes
  cell+               \ one cell to point to the beginning of the list
  allot               \ addr
  dup r> swap !       \ first cell has remaining space
  dup cell+ 0 swap ! ; \ second cell points to the first cell of the list

: list-empty? ( addr -- f )
  true ;
