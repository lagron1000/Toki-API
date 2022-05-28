working on localhost:5143

Server side of the Toki chat app.
Supports the following API calls:
______________________________________________
Contacts


GET
​/api​/Contacts

POST
​/api​/Contacts

GET
​/api​/Contacts​/{id}

PUT
​/api​/Contacts​/{id}

DELETE
​/api​/Contacts​/{id}

GET
​/api​/Contacts​/{id}​/messages

POST
​/api​/Contacts​/{recId}​/messages

GET
​/api​/Contacts​/{recId}​/messages​/{msgId}

PUT
​/api​/Contacts​/{recId}​/messages​/{msgId}

DELETE
​/api​/Contacts​/{recId}​/messages​/{msgId}


______________________________________________
Invitations


GET
​/api​/Invitations

POST
​/api​/Invitations

GET
​/api​/Invitations​/{id}

PUT
​/api​/Invitations​/{id}

DELETE
​/api​/Invitations​/{id}

______________________________________________
Transfer - recieving messages


GET
​/api​/Transfer

POST
​/api​/Transfer

GET
​/api​/Transfer​/{id}

PUT
​/api​/Transfer​/{id}

DELETE
​/api​/Transfer​/{id}

______________________________________________
Users


GET
​/api​/Users

POST
​/api​/Users

GET
​/api​/Users​/{id}

PUT
​/api​/Users​/{id}

DELETE
​/api​/Users​/{id}
