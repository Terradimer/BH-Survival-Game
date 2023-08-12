using System.Collections.Generic;
using System;

namespace DataStructures {
    public class WeightedList<T> {
        private List<(int, T)> list;
        private int totalWeight;

        public WeightedList((int, T)[] inList) {
            list = new List<(int, T)>(inList);
            CalculateWeights();
        }

        public T PullRandom() {
            var random = new Random();
            int index = random.Next(list.Count);

            return list[index].Item2;
        }

        public T PullWeightedRandom() {
            var random = new Random();
            int target = random.Next(totalWeight);

            return BinarySearch(target);
        }

        public void Push((int, T) item) {
            totalWeight += item.Item1;
            list.Add((totalWeight, item.Item2));
        }

        public T Pop(int? index = null) {
            if (list.Count == 0) 
                throw new InvalidOperationException("Cannot pop from an empty list.");
                
            int removeIndex = index ?? list.Count - 1;
            if (removeIndex == list.Count - 1)  return PopFromEnd(removeIndex);

            return PopFromMiddle(removeIndex);
        }

        // Abstraction

        private T PopFromEnd(int removeIndex) {
            totalWeight -= list[removeIndex].Item1;
            if (list.Count > 1) totalWeight += list[removeIndex - 1].Item1;
            
            var item = list[removeIndex].Item2;
            list.RemoveAt(removeIndex);
            return item;
        }

        private T PopFromMiddle(int removeIndex) {
            var item = list[removeIndex].Item2;
            list.RemoveAt(removeIndex);
            CalculateWeights();
            return item;
        }

        private T BinarySearch(int target) {
            int left = 0, right = list.Count - 1;

            while (left < right) {
                int mid = (right + left) / 2;
                if (list[mid].Item1 < target) {
                    left = mid + 1;
                    continue;
                }
                right = mid;
            }

            return list[left].Item2;
        }

        private void CalculateWeights() {
            totalWeight = 0;
            foreach (var item in list) {
                totalWeight += item.Item1;
                list[list.IndexOf(item)] = (totalWeight, item.Item2);
            }
        }
    }
}