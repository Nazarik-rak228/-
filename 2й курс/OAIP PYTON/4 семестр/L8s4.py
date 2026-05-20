# from queue import Queue
# import requests
# from concurrent.futures import ThreadPoolExecutor
# import time

# urls=[
#     "https://edu.1cfresh.com/a/edu_erp_actual/1473240/ru_RU/",
#     "https://edu.1cfresh.com/a/edu_erp_actual/1473240/ru_RU/"
# ]

# def proisv(url):
#     response=requests.get(url)
#     return f"{url}: {len(response.content)} bytes"

# start=time.time()

# # Я дописал эту строку, так как она была перекрыта курсором, но она необходима для работы кода:
# with ThreadPoolExecutor(max_workers=4) as exector:
#     results = exector.map(proisv, urls)

# for result in results:
#     print(result)

# print(f"Затраченое время {time.time()-start:.2f} сек")
# import threading
# import time

# def count(n):
#     while n>0:
#         n-=1

# start= time.time()

# threrds = [threading.Thread(target=count,args=(50_000_000,))for _ in range(4)]

# for t in threrds:
#     t.start()
# for t in threrds:
#     t.join()

# print(f"Потоки {time.time()-start}")

# import time
# start=time.time()
# count(200_000_000)
# print(f"одим поток {time.time()-start}")

# import multiprocessing;
# import os;

# def worker(a):
#     print(f"sas от процесса {a}, pid = {os.getpid()}")

# if __name__ == "__main__":
#     print(os.getpid())
#     p=multiprocessing.Process(target=worker, args=("sasi",))
#     p.start()
#     p.join()
from multiprocessing import Process, Queue

def worker(q):
    q.put((42, "hhhhh", None))

def main():
    q = Queue(maxsize=10) # очередь Ы
    p = Process(target=worker, args=(q,))
    p.start()
    print(q.get())
    p.join()

if __name__ == "__main__":
    main()