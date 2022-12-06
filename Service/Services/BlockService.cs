﻿using Data.Entities;
using Data.Repositories;


namespace Service.Services
{
    public class BlockService
    {
        private readonly BlockRepository _blockRepository;


        public BlockService(BlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public List<Block> GetAll()
        {
            List<Block> blocks = _blockRepository.GetAll().ToList();

            return blocks;
        }

        public Block Add(Block block)
        {
            Block? newBlock = _blockRepository.AddAndSaveChanges(block);

            return newBlock;
        }

        public void Update(Block block)
        {
            _blockRepository.UpdateAndSaveChanges(block);
        }
    }
}