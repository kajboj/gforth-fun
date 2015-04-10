: assert ( addr n f -- )
         \ input:
         \   address of message
         \   length of the message
         \   result of the test as boolean flag
  if
    exception throw
  else
    2drop
  endif ;
