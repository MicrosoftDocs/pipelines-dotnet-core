# Script to deploy the app
# This file is needed only when you want to deploy the app to a Linux VM
sudo add-apt-repository ppa:nginx/stable -y
sudo apt-get update -y
sudo apt-get install git -y

# install nginx
sudo apt-get install nginx -y
sudo rm -f /etc/nginx/sites-enabled/default
sudo cp -f ./nginx-config /etc/nginx/sites-available/example
sudo ln -fs /etc/nginx/sites-available/example /etc/nginx/sites-enabled
sudo service nginx reload

# install supervisor and start the node server as a daemon
sudo apt-get install supervisor -y
npm install pm2 -g -y
pm2 delete example -s
pm2 start server.js -n example
