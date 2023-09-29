import redis

with redis.Redis() as redis_server: # открыть подключение и закрыть после блока кода
    redis_server.lpush("queue", 10)