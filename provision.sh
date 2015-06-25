
wget -qO - https://packages.elastic.co/GPG-KEY-elasticsearch | sudo apt-key add -
echo "deb http://packages.elastic.co/elasticsearch/1.6/debian stable main" | sudo tee -a /etc/apt/sources.list

sudo apt-get update

sudo apt-get install openjdk-7-jre-headless --yes
sudo apt-get install elasticsearch --yes

sudo update-rc.d elasticsearch defaults 95 10
sudo /etc/init.d/elasticsearch start

curl -O https://download.elastic.co/kibana/kibana/kibana-4.1.0-linux-x64.tar.gz
sudo mkdir -p /srv/kibana
sudo tar -C /srv/kibana -zxf kibana-4.1.0-linux-x64.tar.gz --strip 1
/srv/kibana/bin/kibana