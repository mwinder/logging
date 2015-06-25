
Vagrant.configure("2") do |config|
  config.vm.host_name = 'logging'
  config.vm.box = "ubuntu/trusty64"
  config.vm.network :forwarded_port, guest: 9200, host: 9200 # ElasticSearch
  config.vm.network :forwarded_port, guest: 5601, host: 5601 # Kibana

  config.vm.provider :virtualbox do |vb|
      vb.customize ["modifyvm", :id, "--cpus", "2", "--memory", "2048"]
  end

  config.vm.provision "shell", path: "provision.sh"
end
