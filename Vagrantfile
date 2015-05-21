
Vagrant::Config.run do |config|
  config.vm.host_name = 'logging'
  config.vm.box = "ubuntu/trusty64"
  config.vm.forward_port 9292, 9292 # logstash default web
  config.vm.forward_port 9200, 9200 # elasticsearch

  config.vm.customize do |vm|
    vm.memory_size = 1024
  end
end
