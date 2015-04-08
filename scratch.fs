: vsumstep ( a-addr u n1 -- a-addr u n2 )
  over 2over drop swap   \ a-addr u n1 a-addr u
  cells + @ + ;          \ a-addr u n2

: vsumrec ( a-addr u n1 -- n2 )
  over            \ a-addr u n1 u
  0> if           \ a-addr u n1
    swap 1- swap  \ a-addr u-1 n1
    vsumstep
    recurse
  else
    nip nip
  endif ;

: vsum1 ( addr u -- n )
  0 vsumrec ;

: vsum ( addr u -- n )
  0 swap       \ addr 0 u
  0 u+do       \ addr n
    over       \ addr n addr
    i cells +  \ addr n addr1
    @ +        \ addr n1
  loop
  nip ;

create var 5 , 4 , 3 , 2 , 1 ,
var 5 vsum1
var 5 vsum .s
