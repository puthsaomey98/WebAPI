--please run this for docker image and container
docker pull postgres
docker run --name CoreWebAPI -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 postgres
docker container start CoreWebAPI

--open project with asp.net sdk 8.0
remove models folder from project
Open package manager console in vs
run
add-migration first
update-database

-- after seccess all
run project by click run button in vs

