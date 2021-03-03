# Repository Class and Connecting To Postgres

## Setting Up Postgres

### Step 0

Both of your pair create a free [heroku](https://www.heroku.com/) account (you should not need to put in a payment card for what we will be doing).

Heroku is a platform that can host apps, provision data bases and more. We will be using it simply to run a postgres instance for us (for free!).

### Step 1

Download **just** postgresql **command line tools** [using the installer](https://www.postgresql.org/download/).

![](./psql-options.png)

This will allow us to use `psql`, a command line tool for interacting with a database.

Windows users will have to add `psql` [to their path](https://www.architectryan.com/2018/03/17/add-to-the-path-on-windows-10/).

### Step 2

On the Heroku site dashboard, one of the pair create a new app. Add your partner as a collaborator. Go to resources and configure the `Heroku Postgres` add-on. Once you have done this click on your `Heroku Postgres` add-on to be taken to its management pages. Here, navigate to settings and click `View Credentials`. This will page contains all the connection information we need to connect to our postgres database.

### Step 3

Our next task will be to create a table in the database which our app can then use to perform CRUD operations on bootcampers. To do this we will use `psql` to open up a postgres shell, and run some sql commands.

👉 From the credentials list from step 2, copy the URI of your database.

_should be something like this: postgres://jksjh:asf@ec2-1-2-3-4-5.eu-west-1.compute.amazonaws.com:5432/asfasf_

👉 In your terminal, type `psql <your-connection-uri>`

This opens up a shell in which we can write sql commands to interact with the database

👉 One of the pair the contents of `db/createTableAndPopulate.sql` into the shell and press enter.

🎉 You should have created a table!

👉 To prove this, both of you try selecting all the bootcampers using the postgres shell.

### Step 4 - Connecting our App!

Go to `BaseRepository.cs` and locate the connection string builder. Put your credentials from `Heroku Postgres` into the object initialiser.

Run your app with `dotnet run` and set a get request to `/bootcampers`.

🎉 You should receive the bootcampers in your table!

## Dapper Task

Use what we have learned about [dapper](https://github.com/StackExchange/Dapper) to replace the `NotImplementedException`s in the `BootcamperController` with calls to the database.
